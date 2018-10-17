﻿namespace SonmInstaller.Domain

type Service = {
    startDownload:  
        (int64 -> int64 -> unit) ->     // progressCb: bytesDownloaded -> total
        (Result<unit, exn> -> unit) ->  // completeCb
        unit
    openKeyFolder: (*path*) string -> unit
    openKeyFile:   (*path*) string -> unit
}

