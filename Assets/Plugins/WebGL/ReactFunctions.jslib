mergeInto(LibraryManager.library, {

  GetSensorData: function (sensorData) {
    ReactUnityWebGL.GetSensorData(Pointer_stringify(sensorData));
  },

});