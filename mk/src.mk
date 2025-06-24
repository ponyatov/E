# .mk files
MK += Makefile
MK += $(wildcard   mk/*.mk)
MK += $(wildcard   hw/*.mk)
MK += $(wildcard  cpu/*.mk)
MK += $(wildcard arch/*.mk)
MK += $(wildcard   os/*.mk)

# cmake files
CM += CMake* cmake/*.cmake

# C/C++
C += $(wildcard src/*.c*)
H += $(wildcard inc/*.h*)

# ini
S += $(wildcard lib/*.ini) $(wildcard lib/*.f)

# JavaScript
J += $(wildcard src/*.js)

# Python
P += $(wildcard src/*.py)
P += $(wildcard meta/*.py)

# Rust
R += $(wildcard      ./src/*.rs)      ./Cargo.toml
R += $(wildcard config/src/*.rs) config/Cargo.toml
R += $(wildcard server/src/*.rs) server/Cargo.toml

# F#
F += $(wildcard fs/*.fs*)
