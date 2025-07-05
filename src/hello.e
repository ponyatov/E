#!/usr/bin/env Evento
// ^^^^^^^^^^^^^^^^^^ optional shebang: first line only

//! Sample Script code follows...
/*! including language core tests */

// module hello /* defined by file name & path */

/// variables starts with lower letter (low_camel_case)
const WHO = "World"

/// multi-line strings can be wrapped in '' and ""
/// - $"" $'' raw strings, no escapes
/// - @"" @'' format & string interpolation

let hello = $'Hello {who}!'

/// internal logger in code language, traces program execution
/// default logger prints to stderr
/// can be reassigned or duplicated to other streams
/// stdout/stderr streams can be used directly (OS level output)
log hello ; stderr hello

/// check last log lines
test_log "Hello, World!"

let loggers = [log;stderr]
/// - apply functions using container iteration
for f in loggers: f hello
/// - using map, lambda function and pipe operator
loggers.map |f| -> hello |> f
