.PHONY: ai
ai: tmp/$(APP).ai.md
tmp/$(APP).ai.md: doc/*.md fs/*.fs
	cat doc/*.md fs/*.fs > $@ ; touch $@
