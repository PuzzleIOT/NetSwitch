echo "Starting build for project"
echo "Dir: $PWD"

DIR=$PWD

xbuild src/NetSwitch.Tests.sln /p:Configuration=Release
