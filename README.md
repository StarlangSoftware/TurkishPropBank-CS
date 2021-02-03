For Developers
============


You can also see [Java](https://github.com/starlangsoftware/TurkishPropBank), [Python](https://github.com/starlangsoftware/TurkishPropBank-Py), [Swift](https://github.com/starlangsoftware/TurkishPropBank-Swift), or [C++](https://github.com/starlangsoftware/TurkishPropBank-CPP) repository.

Detailed Description
============

+ [FramesetList](#framesetlist)
+ [Frameset](#frameset)

## FramesetList

Frame listesini okumak ve tüm Frameleri hafızada tutmak için

	a = FramesetList();

Framesetleri tek tek gezmek için

	for (int i = 0; i < a.size(); i++){
		Frameset frameset = a.GetFrameset(i);
	}

Bir fiile ait olan Frameseti bulmak için

	frameset = a.GetFrameSet("TUR10-1234560")

## Frameset

Bir framesetin tüm argümanlarını bulmak için

	List<FramesetArgument> GetFramesetArguments()
