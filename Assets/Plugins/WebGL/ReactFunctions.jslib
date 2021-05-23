mergeInto(LibraryManager.library, {

  GetSensorData: function (sensorData) {
    try {
      ReactUnityWebGL.GetSensorData(Pointer_stringify(sensorData));
    }
    catch(err) {
    }
  },

  GetGameState: function (state) {
    try {
      ReactUnityWebGL.GetGameState(Pointer_stringify(state));
    }
    catch(err) {
    }
  }


});