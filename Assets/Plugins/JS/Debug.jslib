var LibraryDebugWebGL = {

	JS_Alert: function(str)
	{
		window.alert(UTF8ToString(str));
	}
};

mergeInto(LibraryManager.library, LibraryDebugWebGL);
