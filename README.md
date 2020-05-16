# Chrono Clash Deck Builder
### [Click here for the site!](https://chronoclashdeckbuilder.azurewebsites.net/)

Chrono Clash Deck Builder is an ASP.NET based web application to create a card database and deck builder for the Chrono Clash card game. The Chrono Clash Card Game is a Living Card Game that incorporates intellectual properties to battle against each other, more information can be found at [The Official Chrono Clash site](https://www.chronoclashsystem.com/en.php). 

On my site, Users will make an account in order to save any decks that they may create. Any Visitor to the site will have access to view the card database and all public Decks on the site. The deck builder will be designed to follow the rules of the game to ensure only legal decks for the game are created.

The current build of [The Chrono Clash Deck Builder](https://chronoclashdeckbuilder.azurewebsites.net/) is up and running. Currently Deck building is limited, and the capability to save/export decks isn't complete at this time. I will make sure to update this page frequently!

<a name="table-of-contents"/>

# Table of contents


<!--ts-->
   * [Database Diagrams](#database-diagrams)
   * [Wireframe Diagrams](#wireframe-diagrams)
   * [Use Case Diagrams](#uml-diagrams)
   * [Requirements](#requirements)
   * [Requirements and Test Table](#requirements-and-test-table)
   * [Card Data](#card-data)
   * [Prototype](#prototype)
<!--te-->
<a name="database-diagrams"/>

### Database Diagrams

![SSMS Database Diagram](https://github.com/Zami77/ChronoClashDeckBuilder/blob/master/ChronoClashDeckBuilder/App_Data/SSMS%20Database%20Diagram.PNG)

![CC Database Diagram](https://github.com/Zami77/ChronoClashDeckBuilder/blob/master/ChronoClashDeckBuilder/App_Data/Chrono%20Clash%20Deck%20Builder.png)

<a name="wireframe-diagrams"/>

### Wireframe Diagrams

![wireframe diagram main](https://github.com/Zami77/ChronoClashDeckBuilder/blob/master/ChronoClashDeckBuilder/App_Data/Wireframe/CC%20Wireframe%20Main%20Page.png)
![wireframe diagram cards](https://github.com/Zami77/ChronoClashDeckBuilder/blob/master/ChronoClashDeckBuilder/App_Data/Wireframe/CC%20Wireframe%20Cards%20Page.png)
![wireframe diagram deck](https://github.com/Zami77/ChronoClashDeckBuilder/blob/master/ChronoClashDeckBuilder/App_Data/Wireframe/CC%20Wireframe%20Decks%20Page.png)
![wireframe diagram deck Builder](https://github.com/Zami77/ChronoClashDeckBuilder/blob/master/ChronoClashDeckBuilder/App_Data/Wireframe/CC%20Wireframe%20Deck%20Builder%20Page.png)

<a name="uml-diagrams"/>

### Use Case Diagram

![UML CC Diagram](https://github.com/Zami77/ChronoClashDeckBuilder/blob/master/ChronoClashDeckBuilder/App_Data/CC%20Use%20Case%20UML.png)

<a name="requirements"/>

### Requirements
User Stories </br>
1 As a Card Game Player I want to view all cards released, so that I know all the cards. </br>
1	 As a Card Game Player I want to build decks so that I can have my decks saved to view later and share to others.</br>

Use-Cases</br>
1 Given user when they click on card list Then all cards are displayed </br>
2 Given user when they apply filters then all cards are filtered</br>
3 Given user when they save deck then the deck is saved to their user account</br>

Requirements</br>
1 User shall log in</br>
2 User shall create an account</br>
3 User shall view cards</br>
4 User shall build decks</br>
5 User shall save decks</br>
6 System shall provide webpage and UI</br>
7 Software shall compile list of Cards</br>
8 Software shall ensure decks that are being built are following the rules</br>
9 Software shall make sure decks are being saved to database</br>
10 Software shall make sure card database is up to date</br>

<a name="requirements-and-test-tables"/>

### Requirements and Test Table

| Requirements ID | Requirement Description                                                  | Test Method |
|-----------------|--------------------------------------------------------------------------|-------------|
| 1               | User Shall Log In                                                        | Test        |
| 2               | User shall create an account                                             | Test        |
| 3               | User shall view cards                                                    | Test        |
| 4               | User shall build decks                                                   | Test        |
| 5               | User shall save decks                                                    | Test        |
| 6               | System shall provide webpage and UI                                      | View        |
| 7               | Software shall compile list of cards                                     | View        |
| 8               | Software shall ensure decks that are being built are following the rules | Test        |
| 9               | Software shall make sure decks are being saved to the database           | Test        |
| 10              | Software shall make sure card database is up to date                     | View        |

| Test ID | Requirements ID | Test Procedure                                   | Current Status | TimeStamp              |
|---------|-----------------|--------------------------------------------------|----------------|------------------------|
| 1       | 1               | Attempt to login with valid and invalid accounts | Success        | 5/16/2020, 10:27:16 AM |
| 2       | 2               | Attempt to create an account then login          | Success        | 5/16/2020, 10:29:21 AM |
| 3       | 3               | Make sure cards are visible                      | Success        | 5/16/2020, 10:29:34 AM |
| 4       | 4               | Attempt to make deck                             | Success        | 5/16/2020, 10:31:11 AM |
| 5       | 5               | Attempt to save deck                             | Success        | 5/16/2020, 10:31:40 AM |
| 6       | 6               | View all web pages                               | Success        | 5/16/2020, 10:32:12 AM |
| 7       | 7               | View list of cards                               | Success        | 5/16/2020, 10:31:53 AM |
| 8       | 8               | View if deck is created with invalid parameters  | Success        | 5/16/2020, 10:32:12 AM |
| 9       | 9               | Save deck and see if it's saved to the account   | Success        | 5/16/2020, 10:31:40 AM |
| 10      | 10              | View cards and make sure they are up to date     | Success        | 5/16/2020, 10:32:12 AM |

### Card Data

An excel file for the [Card Data](https://1drv.ms/x/s!As_NDUCOYXoGgd5wPTa4tM9WGTctVg?e=bKFpsZ). These sheets automatically produces a SQL Query to be inserted into the database.

### Prototype

Link to the [Prototype](https://github.com/Zami77/ChronoClashDeckBuilder/tree/master/Prototype) ReadMe

