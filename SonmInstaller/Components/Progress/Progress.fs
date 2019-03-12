﻿namespace SonmInstaller.Components.Progress

type ProgressStyle = Continuous | Marquee

type State = {
    captionTpl: string // Template can have up to 3 placeholders: current value, total, percent
    style: ProgressStyle
    current: float
    total: float
}

type Msg<'arg, 'res> = 
    | Start of 'arg
    | Progress of State
    | Complete of Result<'res, exn>

namespace SonmInstaller.Components
open SonmInstaller.Components.Progress

[<AutoOpen>]
module ProgressHelpers = 
    open Elmish


    module Progress = 
        let defaultValue =
            {
                captionTpl = "Progress: {0:0.0} of {1:0.0} ({2:0}%)"
                style = ProgressStyle.Marquee
                current = 0.0
                total = 0.0
            }

        let start (msg: Msg<'arg,'res> -> 'msg) (arg: 'arg) = 
            Cmd.ofSub (fun d -> Msg.Start arg|> msg |> d)