
EXTRA_DIST =  Makefile

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=..

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;" "-main:inteliBOT.MainClass"
ASSEMBLY = bin/Debug/inteliBOT.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = exe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

INTELIBOT_EXE_MDB_SOURCE=bin/Debug/inteliBOT.exe.mdb
INTELIBOT_EXE_MDB=$(BUILD_DIR)/inteliBOT.exe.mdb
INTELIBOT_EXE_CONFIG_SOURCE=App.config
IQTOOLKIT_DLL_SOURCE=../../Descargas/linqtowiki/LINQ-to-Wiki-master/LinqToWiki.Core/bin/Debug/IQToolkit.dll
LINQTOWIKI_CORE_DLL_SOURCE=../../Descargas/linqtowiki/LINQ-to-Wiki-master/LinqToWiki.Core/bin/Debug/LinqToWiki.Core.dll
LINQTOWIKI_CORE_DLL_MDB_SOURCE=../../Descargas/linqtowiki/LINQ-to-Wiki-master/LinqToWiki.Core/bin/Debug/LinqToWiki.Core.dll.mdb
RESTSHARP_DLL_SOURCE=../../Descargas/linqtowiki/LINQ-to-Wiki-master/LinqToWiki.Core/bin/Debug/RestSharp.dll
LINQTOWIKI_GENERATED_DLL_SOURCE=../../Descargas/linqtowiki/LINQ-to-Wiki-master/Lib/LinqToWiki.Generated/LinqToWiki.Generated.dll

endif

ifeq ($(CONFIG),RELEASE_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- "-main:inteliBOT.MainClass"
ASSEMBLY = bin/Release/inteliBOT.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = exe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

INTELIBOT_EXE_MDB=
INTELIBOT_EXE_CONFIG_SOURCE=App.config
IQTOOLKIT_DLL_SOURCE=../../Descargas/linqtowiki/LINQ-to-Wiki-master/LinqToWiki.Core/bin/Debug/IQToolkit.dll
LINQTOWIKI_CORE_DLL_SOURCE=../../Descargas/linqtowiki/LINQ-to-Wiki-master/LinqToWiki.Core/bin/Debug/LinqToWiki.Core.dll
LINQTOWIKI_CORE_DLL_MDB_SOURCE=../../Descargas/linqtowiki/LINQ-to-Wiki-master/LinqToWiki.Core/bin/Debug/LinqToWiki.Core.dll.mdb
RESTSHARP_DLL_SOURCE=../../Descargas/linqtowiki/LINQ-to-Wiki-master/LinqToWiki.Core/bin/Debug/RestSharp.dll
LINQTOWIKI_GENERATED_DLL_SOURCE=../../Descargas/linqtowiki/LINQ-to-Wiki-master/Lib/LinqToWiki.Generated/LinqToWiki.Generated.dll

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(INTELIBOT_EXE_MDB) \
	$(INTELIBOT_EXE_CONFIG) \
	$(IQTOOLKIT_DLL) \
	$(LINQTOWIKI_CORE_DLL) \
	$(LINQTOWIKI_CORE_DLL_MDB) \
	$(RESTSHARP_DLL) \
	$(LINQTOWIKI_GENERATED_DLL)  

BINARIES = \
	$(INTELIBOT)  


RESGEN=resgen2

INTELIBOT_EXE_CONFIG = $(BUILD_DIR)/inteliBOT.exe.config
IQTOOLKIT_DLL = $(BUILD_DIR)/IQToolkit.dll
LINQTOWIKI_CORE_DLL = $(BUILD_DIR)/LinqToWiki.Core.dll
LINQTOWIKI_CORE_DLL_MDB = $(BUILD_DIR)/LinqToWiki.Core.dll.mdb
RESTSHARP_DLL = $(BUILD_DIR)/RestSharp.dll
LINQTOWIKI_GENERATED_DLL = $(BUILD_DIR)/LinqToWiki.Generated.dll
INTELIBOT = $(BUILD_DIR)/intelibot

FILES = \
	Main.cs \
	AssemblyInfo.cs \
	login.cs \
	Scripts/help.cs \
	Scripts/replace.cs \
	DownloadPage.cs \
	Site.cs \
	Scripts/vote.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	App.config \
	Scripts \
	intelibot.in 

REFERENCES =  \
	System \
	System.Xml \
	System.Xml.Linq \
	System.Web \
	System.Configuration \
	System.Data.Linq

DLL_REFERENCES =  \
	../../Descargas/linqtowiki/LINQ-to-Wiki-master/LinqToWiki.Core/bin/Debug/IQToolkit.dll \
	../../Descargas/linqtowiki/LINQ-to-Wiki-master/LinqToWiki.Core/bin/Debug/LinqToWiki.Core.dll \
	../../Descargas/linqtowiki/LINQ-to-Wiki-master/LinqToWiki.Core/bin/Debug/RestSharp.dll \
	../../Descargas/linqtowiki/LINQ-to-Wiki-master/Lib/LinqToWiki.Generated/LinqToWiki.Generated.dll

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

#Targets
all: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES)  $(top_srcdir)/config.make

include $(top_srcdir)/Makefile.include
#include $(srcdir)/custom-hooks.make



$(eval $(call emit-deploy-target,INTELIBOT_EXE_CONFIG))
$(eval $(call emit-deploy-target,IQTOOLKIT_DLL))
$(eval $(call emit-deploy-target,LINQTOWIKI_CORE_DLL))
$(eval $(call emit-deploy-target,LINQTOWIKI_CORE_DLL_MDB))
$(eval $(call emit-deploy-target,RESTSHARP_DLL))
$(eval $(call emit-deploy-target,LINQTOWIKI_GENERATED_DLL))
$(eval $(call emit-deploy-wrapper,INTELIBOT,intelibot,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'


$(ASSEMBLY_MDB): $(ASSEMBLY)
$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	make pre-all-local-hook prefix=$(prefix)
	mkdir -p $(shell dirname $(ASSEMBLY))
	make $(CONFIG)_BeforeBuild
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
	make $(CONFIG)_AfterBuild
	make post-all-local-hook prefix=$(prefix)

install-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-install-local-hook prefix=$(prefix)
	make install-satellite-assemblies prefix=$(prefix)
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)'
	$(call cp,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(INTELIBOT_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(INTELIBOT_EXE_CONFIG),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(IQTOOLKIT_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(LINQTOWIKI_CORE_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(LINQTOWIKI_CORE_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(RESTSHARP_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(LINQTOWIKI_GENERATED_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(bindir)'
	$(call cp,$(INTELIBOT),$(DESTDIR)$(bindir))
	make post-install-local-hook prefix=$(prefix)

uninstall-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-uninstall-local-hook prefix=$(prefix)
	make uninstall-satellite-assemblies prefix=$(prefix)
	$(call rm,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(INTELIBOT_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(INTELIBOT_EXE_CONFIG),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(IQTOOLKIT_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(LINQTOWIKI_CORE_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(LINQTOWIKI_CORE_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(RESTSHARP_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(LINQTOWIKI_GENERATED_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(INTELIBOT),$(DESTDIR)$(bindir))
	make post-uninstall-local-hook prefix=$(prefix)

install: install-local
uninstall: uninstall-local
clean: clean-local

include $(top_srcdir)/rules.make
