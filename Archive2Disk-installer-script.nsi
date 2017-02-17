; The name of the installer
Name "Archive2Disk"

; The file to write
OutFile "Archive2Disk-setup.exe"

; The default installation directory
InstallDir $PROGRAMFILES\Archive2Disk

; Registry key to check for directory (so if you install again, it will 
; overwrite the old one automatically)
InstallDirRegKey HKLM "Software\Archive2Disk" "Install_Dir"

; Request application privileges for Windows Vista
RequestExecutionLevel admin

;--------------------------------

; Pages

Page components
Page directory
Page instfiles

UninstPage uninstConfirm
UninstPage instfiles

;--------------------------------

; The stuff to install
Section "Archive2Disk (required)"

  SectionIn RO
  
  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  ; Put file there
  File "Archive2Disk\bin\Release\app.publish\setup.exe"
  File "Archive2Disk\bin\Release\app.publish\Archive2Disk.vsto"
  File /r "Archive2Disk\bin\Release\app.publish\*.*"
  
  ; Write the installation path into the registry
  WriteRegStr HKLM SOFTWARE\Archive2Disk "Install_Dir" "$INSTDIR"
  
  ExecWait '"$INSTDIR\setup.exe"'
  
  ; Write the uninstall keys for Windows
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Archive2Disk" "DisplayName" "Archive2Disk"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Archive2Disk" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Archive2Disk" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Archive2Disk" "NoRepair" 1
  WriteUninstaller "uninstall.exe"
SectionEnd

; Uninstaller

Section "Uninstall"
  
  ; Remove directories & files used
  RMDir /r "$SMPROGRAMS\Archive2Disk"
  RMDir /r "$INSTDIR"
  
SectionEnd