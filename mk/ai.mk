.PHONY: ai
ai: tmp/$(APP).ai.md
tmp/$(APP).ai.md: README.md doc/*.md lib/*.fs* lib/*.e $(MK)
	cat README.md doc/*.md lib/*.fs* lib/*.e ~/metadoc/syntax/tabbed* > $@
