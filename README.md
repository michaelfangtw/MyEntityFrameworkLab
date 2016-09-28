MyEntityFrameworkLab
-----
This is a Data Access Layer(DAL) sample that built with EntityFramework 6 <br>
```
Models\Repository  (Data Access Layer)
Models\Service     (Business Logic Layer)
Models\ViewModel   (ViewModel for displaying data in View)
```

Installation
------------
```
git clone MySingletonMultiDatabase https://github.com/michaelfangtw/MyEntityFrameworkLab.git
```

Git Notes
------------
```
d:
cd D:\git\MyEntityFrameworkLab
git init
git add .
git status
git commit -m "first commit"
rem MyCodeFirstLab
git remote add origin https://github.com/michaelfangtw/MyEntityFrameworkLab.git
rem origin =remote repos
rem master =local repos
git push -u origin master
```

Usage
------------
Open /source/MyEntityFrameworkLab.sln via Visual Studio 2015

Issues
-------
Found a bug? Create an issue on GitHub.


For transparency and insight into the release cycle, releases will be numbered with the follow format:

`<major>.<minor>.<patch>`

And constructed with the following guidelines:

* Breaking backwards compatibility bumps the major (無法向前相容)
* New additions without breaking backwards compatibility bumps the minor (可向前相容的功能新增)
* Bug fixes and misc changes bump the patch (修正Bug)

For more information on semantic versioning, please visit http://semver.org/.

License
-------

Copyright (c) 2016 [Michael Fang](http://funtech.tw)  
Licensed under the MIT License.











