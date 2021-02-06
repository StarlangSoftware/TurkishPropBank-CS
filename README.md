For Developers
============


You can also see [Java](https://github.com/starlangsoftware/TurkishPropBank), [Python](https://github.com/starlangsoftware/TurkishPropBank-Py), [Cython](https://github.com/starlangsoftware/TurkishPropBank-Cy), [Swift](https://github.com/starlangsoftware/TurkishPropBank-Swift), or [C++](https://github.com/starlangsoftware/TurkishPropBank-CPP) repository.

## Requirements

* C# Editor
* [Git](#git)

### Git

Install the [latest version of Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git).

## Download Code

In order to work on code, create a fork from GitHub page. 
Use Git for cloning the code to your local or below line for Ubuntu:

	git clone <your-fork-git-link>

A directory called TurkishPropBank-CS will be created. Or you can use below link for exploring the code:

	git clone https://github.com/starlangsoftware/TurkishPropBank-CS.git

## Open project with Rider IDE

To import projects from Git with version control:

* Open Rider IDE, select Get From Version Control.

* In the Import window, click URL tab and paste github URL.

* Click open as Project.

Result: The imported project is listed in the Project Explorer view and files are loaded.


## Compile

**From IDE**

After being done with the downloading and opening project, select **Build Solution** option from **Build** menu. After compilation process, user can run TurkishPropBank-CS.

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
