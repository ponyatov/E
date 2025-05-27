#!/usr/bin/env evento
// empty file

-01 +0230 0xDeadBeef 0o750 0b1101 /* numbers */



actor Actor {
    const ShowMustGoOn = true
    on init()
    on halt(){}
}

actor Logger:Actor {
    on log(){}
}
