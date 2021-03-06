echo "Getting library files"
echo "  Dir: $PWD"

LIB_DIR=$PWD

NUGET_FILE="nuget.exe"

if [ ! -f "$NUGET_FILE" ];
then
    echo "Getting nuget.exe..."
    wget http://nuget.org/nuget.exe -q
fi

echo "Updating nuget.exe..."
mono nuget.exe update -self

if [ ! -d "duinocom.core.1.0.6" ]; then
    mono nuget.exe install duinocom.core -version 1.0.6
fi

if [ ! -d "NUnit.2.6.4" ]; then
    mono nuget.exe install nunit -version 2.6.4
fi

if [ ! -d "NUnit.Runners.2.6.4" ]; then
    mono nuget.exe install nunit.runners -version 2.6.4
fi

if [ ! -d "ArduinoSerialControllerClient.1.0.9" ]; then
    mono nuget.exe install ArduinoSerialControllerClient -version 1.0.9
fi
