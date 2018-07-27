PORT=$1
ARGUMENTS=""

if [ "$PORT" ]; then
  ARGUMENTS=" --port $PORT"
fi

pio device monitor $ARGUMENTS
