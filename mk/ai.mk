.PHONY: ai tmp/$(APP).ai.md
ai: tmp/$(APP).ai.md
tmp/$(APP).ai.md:
	cat README.md doc/*.md *.fsproj lib/*.fs* src/*.e ~/metadoc/syntax/tabbed* > $@
