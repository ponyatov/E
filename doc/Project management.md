# Project management

> compiler options for 
> - project metainformation
> - [[E/Modules|module]] management

[[E/E|E]] compiler merges in a single binary:
- [[E/REPL|REPL]]
	- [[LSP]] server
	- [[E/Debugger|Debugger]]
- [[compiler/cross-compiler|cross-compiler]]
	- [[E/E|E]] is a cross-compile first language:
		- self-hosted compiler able to build itself by [[Canadian Cross]]
		- [[E/HOST|HOST]]-only compilation is only a special case
	- [[E/TARGET|target]] hardware interface via
		- [[OpenOCD]]
		- [[gdb/stub|stub]]
- project/module manager
	- project metainformation
	- external module management
		- [[git/GitHub|GitHub]], [[GitFlic]], [[GitLab]] repositories
		- public & private HTTP(s) storage supported by package vendors
		- decentralized module registry (no global indexes)
- syntax code [[E/autoformat|autoformatter]]
