OS      = linux
 TARGET = x86_64-linux-gnu
RTARGET = stable-x86_64-unknown-linux-gnu
QEMU    = qemu-system-$(ARCH)
APT    += gcc qemu-system-x86 syslinux isolinux
