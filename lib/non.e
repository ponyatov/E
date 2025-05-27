#!/usr/bin/env evento
// empty file


actor Actor {
    const ShowMustGoOn = true
    on init()
    on halt(){}
}

actor Logger:Actor {
    on log(){}
}
