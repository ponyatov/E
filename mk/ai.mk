.PHONY: ai
ai: tmp/$(APP).ai.md
tmp/$(APP).ai.md: README.md doc/$(APP).md $(F) $(MK)
	cat README.md doc/$(APP).md $(F) > $@
