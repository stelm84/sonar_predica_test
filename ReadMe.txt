Preconditions: Chrome Browser installed, internet access

Clone the project into your local machine
  SSH: git@gitlab.com:stel_m/predica.git
  HTTPS: https://gitlab.com/stel_m/predica.git
  or visit the Project on Web and use 'download' option

1# Run from Visual studio:
- clone the project into your local machine
- open the project in your Visual Studio by pointing to PredicaTask.sln file
- when project is fully loaded into your VS build the solution, menu: Build -> Build Solution
- you should see the 'Build: 1 succeeded..' in you output pane of VS
- got to menu: Test -> Windows -> Test Explorer to bring on the 'Test Explorer' pane into your workspace (if you don't have it already)
- run the test by clicking either 'Run All' or clicking the test RightMouseButton and then "Run Selected Tests"
- you should see test starting and performing actions on your Chrome Browser
- after run you can expand the tests tree in your 'Test Explorer' pane and click the 'Output' link to see the test results

2# Run from your Windows console by NUnit.ConsoleRunner 
- to be able to run this variant NUnit.ConsoleRunner should be installed in localization with admin rights - NUnit.Console will try to save 
	the TestResult.xml by default in it's home directory
- visit https://github.com/nunit/nunit-console/releases and choose appropriate installation package for your environment, i.e. 'NUnit.Console-3.10.0.msi' and install it
- once NUnit.Console is installed you can find executable file in your installation destination under 'tools' subfolder: 'nunit3-console.exe'
- open your console prompt and go to folder where NUnit.Console has been installed
- run 'nunit3-console.exe' and point it to the project path + '/PredicaTask/bin/Debug/PredicaTask.dll' press Enter
- example console command: 'nunit3-console.exe C:\Users\Marcin\source\repos\PredicaTask\PredicaTask\bin\Debug\PredicaTask.dll'
- test should be run and outcome should be visible in your console prompt
