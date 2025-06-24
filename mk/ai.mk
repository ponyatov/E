.PHONY: ai
ai: tmp/$(APP).ai.md
tmp/$(APP).ai.md: README.md doc/*.md $(F)
	cat README.md doc/*.md $(F) > $@
