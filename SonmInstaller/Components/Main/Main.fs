﻿namespace SonmInstaller.Components.Main

open SonmInstaller.Components
open SonmInstaller.Tools

type Screen = 
    | S0Welcome = 0
    | S1DoYouHaveWallet = 1
    | S2a1KeyGen = 2
    | S2a2KeyGenSuccess = 3
    | S2b1SelectJson = 4
    | S2b2JsonPassword = 5
    | S3MoneyOut = 6
    | S4SelectDisk = 7
    | S5Progress = 8
    | S6Finish = 9
    
type Step = Screen * int // screen * stepNum

type InstallationProgress =
    | WaitForStart
    | Downloading
    | DownloadComplete of Result<unit, exn>

type MessagePage = {
    header: string
    message: string
    tryAgainVisible: bool
}

type ExistingKeystore = {
    path: string option
    password: string
}

type Withdraw = {
    address: string
    thresholdPayout: string
}

type Show = ShowStep | ShowMessagePage of MessagePage

type State = {
    currentStep: Step
    stepsHistory: Step list
    show: Show
    installationProgress: InstallationProgress
    backButton: Button.State
    nextButton: Button.State
    isPending: bool
    // progress:
    hasWallet: bool
    newKeyState: NewKeyPage.State
    existingKeystore: ExistingKeystore
    etherAddress: string option
    withdraw: Withdraw
    selectedDrive: ListItem option
}
with
    member this.IsAtBeginning () = this.stepsHistory = []
    member this.HistoryTail () =
        match this.stepsHistory with
        | _::tail -> tail
        | _ -> []
    member this.PrevStep () = 
        match this.stepsHistory with
        | head::_ -> head
        | _ -> this.currentStep
    member this.CurrentScreen () = this.currentStep |> fst
    member this.CurrentStepNum () = this.currentStep |> snd


namespace SonmInstaller.Components.Main.Msg

open SonmInstaller.Components
open SonmInstaller.Components.Main
open SonmInstaller.Tools

type Download = 
    | Start
    | Progress of int64 * int64 // bytes downloaded * total
    | Complete of Result<unit, exn>

type AsyncTask<'r> = 
    | Start 
    | Complete of Result<'r, exn>

type ImportKey = 
    | ChoosePath of string
    | ChangePassword of string
    | Import of AsyncTask<string>

type WithdrawMsg = 
    | Address of string
    | Threshold of string

type Msg =
    | BackBtn
    | NextBtn
    | Download of Download
    | HasWallet of bool
    | NewKeyMsg of NewKeyPage.Msg
    | GenerateKey of AsyncTask<string>
    | OpenKeyDir
    | OpenKeyFile
    | ImportKey of ImportKey
    | Withdraw of WithdrawMsg
    | CallSmartContract of AsyncTask<unit>
    | SelectDrive of ListItem
    | MakeUsbStick of AsyncTask<unit>