<#

Backup source code project

.AUTHOR
  Sevcik Jiri (mailto:jsevcik@cs.mfcr.cz)
  Phone: +420 601 587 421

.CREATED
  5. 11. 2021

.LAST UPDATE
  5. 11. 2021

Copyright (c) 2021 SJ, odd. GRC 128.1 - Informatiky Brno
  
#>

$appName = "PUXTask"

$7zipPath = "$env:ProgramFiles\7-Zip\7z.exe"

if (-not (Test-Path -Path $7zipPath -PathType Leaf)) {
    throw "7 zip file '$7zipPath' not found"
}

Set-Alias 7zip $7zipPath

$source = ".\" + $appName

$date = Get-Date -format "yyyy-MM-dd"
$target = "C:\Users\jiri\Documents\Backups\" + $appName + "_"+ $date + ".7z"

7zip a -mx=9 $target $source -xr!bin -xr!obj -xr!node_modules -xr!downloads