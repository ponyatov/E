# breakloop

A **[[breakloop]]** is a full-featured [[E/REPL|REPL]], complete with all of the tools of the main repl, but it exists inside the dynamic environment of the broken function. From the breakloop you can roam up and down the suspended call stack, examining all variables that are lexically visible from each stack frame. In fact, you can inspect all live data in the running program.

What’s more, **you can _edit_ all live data in the program**. If you think that a break was caused by a wrong value in some particular variable or field, you can interactively change it and resume or restart the suspended function. If it now works correctly, then congratulations; you found the problem!
