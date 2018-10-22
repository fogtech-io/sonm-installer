﻿namespace SonmInstaller.Domain

open SonmInstaller
open SonmInstaller.Components

type Service = 
    {
        // NewKeyPage.IService
        getUtcFilePath: unit -> string
        
        // Main.IService
        startDownload:  
            (int64 -> int64 -> unit) ->     // progressCb: bytesDownloaded -> total
            (Result<unit, exn> -> unit) ->  // completeCb
            unit
        generateKeyStore: string -> string -> Async<string> // path -> password -> address
        importKeyStore  : string -> string -> Async<string>
        openKeyFolder: (*path*) string -> unit
        openKeyFile:   (*path*) string -> unit
        callSmartContract: string -> float -> Async<unit>
        makeUsbStick: int -> Async<unit>
        closeApp: unit -> unit
    } 
    interface NewKeyPage.IService with
        member x.GetUtcFilePath () = x.getUtcFilePath ()
        
    interface Main.IService with
        member x.StartDownload progressCb completeCb = x.startDownload progressCb completeCb
        member x.GenerateKeyStore path password = x.generateKeyStore path password
        member x.ImportKeyStore   path password = x.importKeyStore path password
        member x.OpenKeyFolder path = x.openKeyFolder path
        member x.OpenKeyFile path = x.openKeyFile path
        member x.CallSmartContract withdrawTo minPayout = x.callSmartContract withdrawTo minPayout
        member x.MakeUsbStick drive = x.makeUsbStick drive
        member x.CloseApp () = x.closeApp ()
