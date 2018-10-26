﻿module SonmInstaller.Domain.Mock

open System
open System.IO
open System.Threading
open System.Diagnostics
open SonmInstaller

module private Impl =

    let debugWrite header message = Debug.WriteLine ("{0}: {1}", header, message)

    let waitReturn ms msg res = async {
        printfn "%s: Begin" msg
        do! Async.Sleep ms
        printfn "%s: End" msg
        return res
    }

open Impl

let immidiatelyDownload 
    (progressCb: int64 -> int64 -> unit) 
    (completeCb: Result<unit, exn> -> unit) =
    printfn "Downloading progress"
    progressCb 1L 1L
    printfn "Downloading complete"
    completeCb (Ok ())

let download 
    time         // ms
    totalBytes
    (progressCb: int64 -> int64 -> unit) 
    (completeCb: Result<unit, exn> -> unit) =
        
    let deltaTime = 100  // ms
    let batch = (float totalBytes) / ((float time) / (float deltaTime))

    let rec loop progress =
        Thread.Sleep deltaTime
        progressCb progress totalBytes
        if progress < totalBytes then
            loop (progress + int64 batch)
        else 
            completeCb (Ok ())

    Async.Start <| async {
        loop 0L
    } 
        
    Console.WriteLine("StartDownload")

let makeUsbStick time totalEntries _ (progress: int -> int -> unit) = async { //ToDo: simplify
    let delta = (float time) / (float totalEntries) |> int
    let rec loop processedEntries = async {
        do! Async.Sleep delta
        progress processedEntries totalEntries
        if processedEntries < totalEntries then
            do! loop (processedEntries + 1)
    }
    return! loop 0
}

let createEmptyService asyncTasksWait = 
    let address = "0x689c56aef474df92d44a1b70850f808488f9769c"
    let ms = asyncTasksWait
    let wait = Impl.waitReturn
    {
        getUtcFilePath    = (fun _ -> Path.Combine (Tools.appPath, "key.json"))
        getUsbDrives      = (fun _ -> [(91, "X:"); (91, "Y:")])
        startDownload     = immidiatelyDownload
        generateKeyStore  = (fun _ _ -> wait ms "generateKeyStore" address)
        importKeyStore    = (fun _ _ -> wait ms "importKeyStore" address)
        openKeyFolder     = debugWrite "openKeyFolder"
        openKeyFile       = debugWrite "openKeyFile"
        callSmartContract = (fun _ _ -> wait ms "callSmartContract" ())
        makeUsbStick      = makeUsbStick 1000 10
        closeApp          = id
    }

