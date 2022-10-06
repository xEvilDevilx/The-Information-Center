# The Information Center
The Information Center is an information kiosk based system. The main purposes is to show a retail items information (image, price, description, advertising, etc) by scan of the retail item barcode.

Primary I designed and developed this information system for a commercial buisness purposes. This is a completed working system.

Main parts of the system are:
1. SDK (.net3.5 compact framework)
2. SDK (.net4.6.1)
3. License Manager (.net3.5 compact framework)
4. License Manager (.net4.6.1)
5. Terminal (kiosk) based solution (.net3.5 compact framework)
6. Terminal (kiosk) based solution (.net4.6.1)
7. Server side Service based solution (.net4.6.1)
8. Analyst (.net4.6.1)
9. Currency Rates Tool service (.net4.6.1)
10. Documents ("Tutorial for Creating License", "Creating Plugin (non-completed)", "C# Code Style", "IC Development info")
11. Demonstration and empty Databases
12. Test data for local testing
13. Publishes folder which contains a debug build for local testing

<b>Warning! For to build .net3.5CF solutions need a Visual Studio 2008!</b>
Also .net3.5CF solutions were developed for a Zebra MK3100 kiosk and didn't tested to work with any others.
Also the main solution contains code for work with custom ADO.Net based CRM and code for work with Entity Framework.

Deploying (for .net4.6.1 for example):
1. Start and build a SDK solution
2. Start and build a License Manager solution
3. Generate and setup a new license (/Information Center/Docs/Tutorials/Licence Manager/Information Center. Лицензирование IC.pdf)
3. Start and build a Terminal solution
4. Start and build a server side Windows Service solution
5. Install, configure (set connection string to database in app config file) and start a server side Service
6. Copy to the Terminal a built terminal solution and start it

Sorry, but included docs has a Russian language not translated to English

