###
# Docker
###

MOUNT_PATH := $(shell echo $${LOCAL_WORKSPACE_FOLDER:-$$(pwd)})
DOCKER_INTERACTIVE := true
VERSION_CSPELL ?= latest
VERSION_MARKDOWNLINT ?= latest

.PHONY: explain
explain:
	@awk 'BEGIN {FS = ":.*##"; printf "\nUsage:\n  make \033[36m\033[0m\n"} /^[a-zA-Z_-]+:.*?##/ { printf "  \033[36m%-20s\033[0m %s\n", $$1, $$2 } /^##@/ { printf "\n\033[1m%s\033[0m\n", substr($$0, 5) } ' $(MAKEFILE_LIST)

###
##@ Cleanup
###

.PHONY: clean-everything
clean-everything: clean-packages clean-solution clean-containers ## Clean the repo

.PHONY: clean-packages
clean-packages: ## Clean installed packages
	@echo "Cleaning packages installed"
	yarn cache clean
	rm -fr node_modules
	@echo "✔ Done"

.PHONY: clean-solution
clean-solution: ## Clean .NET solution
	dotnet clean functional-programming/csharp/src/FunctionalProgramming.Exercises.csproj

.PHONY: clean-containers
clean-containers: ## Clean Docker containers
	@echo "Cleaning Docker containers"
	docker rmi $(shell docker images --format '{{.Repository}}:{{.Tag}}' | grep -e 'ghcr.io/streetsidesoftware/cspell' -e 'peterdavehello/npm-doctoc' -e 'davidanson/markdownlint-cli2') | true
	@echo "✔ Done"

###
##@ Installation
###

.PHONY: install-everything
install-everything: install-packages ## Install package manager and packages

.PHONY: init-pkg-manager
init-pkg-manager: ## Initialize package manager
	@echo "Initializing Yarn package manager"
	corepack enable
	@echo "✔ Done"

.PHONY: install-packages
install-packages: init-pkg-manager ## Install Node packages
	@echo "Installing Node packages"
	yarn install
	@echo "✔ Done"

###
##@ Validation
###

.PHONY: check-spelling
check-spelling: check-interactive set-interactive ## Check spelling in markdown files
	@echo "- Spell-checking..."
	docker run --rm $(DOCKER_INTERACTIVE_FLAGS) \
		-v $(MOUNT_PATH):/workdir \
		ghcr.io/streetsidesoftware/cspell:$(VERSION_CSPELL) \
		"**/*.{js,json,md,txt}"
	@echo "✔ Done"

.PHONY: lint-markdown
lint-markdown: check-interactive set-interactive ## Lint markdown files
	@echo "- Linting markdown files..."
	docker run --rm $(DOCKER_INTERACTIVE_FLAGS) \
		-v $(MOUNT_PATH):/workdir \
		davidanson/markdownlint-cli2:$(VERSION_MARKDOWNLINT)
	@echo "✔ Done"

###
# Docker flags configuration
# This allows us to see the results from container executables (like cspell)
# when we run it manually, and switch the interactive mode off when running
# them from husky.
###

.PHONY: check-interactive
check-interactive:
ifeq ($(DOCKER_INTERACTIVE),)
	@echo "[Error] Please specify DOCKER_INTERACTIVE"
	@exit 1;
endif

.PHONY: set-interactive
set-interactive:
ifeq ($(DOCKER_INTERACTIVE),true)
	$(eval DOCKER_INTERACTIVE_FLAGS=-it)
else
	$(eval DOCKER_INTERACTIVE_FLAGS=-t)
endif
