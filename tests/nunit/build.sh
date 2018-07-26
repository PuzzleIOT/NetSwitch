echo "Starting build for project"
echo "Dir: $PWD"

DIR=$PWD

xbuild src/NetSwitch.sln /p:Configuration=Release
