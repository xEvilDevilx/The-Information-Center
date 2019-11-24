# The Information Center
The Information Center is an information kiosk based system. The main purposes is to show a retail items information (image, price, description, advertising, etc) by scan of the retail item barcode.

Primary I developed this information system for a commercial buisness purposes. This is a completed working system.

Main parts of the system are:
1. SDK (.net3.5 compact framework)
2. SDK (.net4.6.1)
3. License Manager (.net3.5 compact framework)
4. License Manager (.net4.6.1)
5. Terminal (kiosk) based solution (.net3.5 compact framework)
6. Terminal (kiosk) based solution (.net4.6.1)
7. Server side Service based solution (.net4.6.1)

Deploying (for .net4.6.1 for example):
1. Start and build a SDK solution
2. Start and build a License Manager solution
3. Generate and setup a new license (/Information Center/Docs/Tutorials/Licence Manager/Information Center. Лицензирование IC.pdf)
3. Start and build a Terminal solution
4. Start and build a server side Windows Service solution
5. Install, configure (set connection string to database in app config file) and start a server side Service
6. Copy to the Terminal a built terminal solution and start it
