# Chrono Clash Deck Builder
Chrono Clash Deck Builder is an ASP.NET based web project to create a card database and deck builder for the Chorno Clash card game. The Chrono Clash Card Game is a Living Card Game that incorporates intellectual properties to battle against each other, more information can be found at [The Official Chrono Clash site](https://www.chronoclashsystem.com/en.php). 

Users will make an account in order to save any decks that they may create. Any Visitor to the site will have access to view the card database and all public Decks on the site. The deck builder will be designed to follow the rules of the game to ensure only legal decks for the game are created.

<a name="table-of-contents"/>

# Table of contents


<!--ts-->
   * [Database Diagrams](#database-diagrams)
   * [Wireframe Diagrams](#wireframe-diagrams)
   * [UML Diagrams](#uml-diagrams)
   * [Requirements](#requirements)
   * [Requirements and Test Table](#requirements-and-test-table)
   * [Card Data](#card-data)
   * [Prototype](#prototype)
<!--te-->
<a name="database-diagrams"/>

### Database Diagrams

![CC Database Diagram](https://github.com/Zami77/ChronoClashDeckBuilder/blob/master/ChronoClashDeckBuilder/App_Data/Chrono%20Clash%20Deck%20Builder.png)

<a name="wireframe-diagrams"/>

### Wireframe Diagrams

![wireframe diagram main](https://github.com/Zami77/ChronoClashDeckBuilder/blob/master/ChronoClashDeckBuilder/App_Data/Wireframe/CC%20Wireframe%20Main%20Page.png)
![wireframe diagram cards](https://github.com/Zami77/ChronoClashDeckBuilder/blob/master/ChronoClashDeckBuilder/App_Data/Wireframe/CC%20Wireframe%20Cards%20Page.png)
![wireframe diagram deck](https://github.com/Zami77/ChronoClashDeckBuilder/blob/master/ChronoClashDeckBuilder/App_Data/Wireframe/CC%20Wireframe%20Decks%20Page.png)
![wireframe diagram deck Builder](https://github.com/Zami77/ChronoClashDeckBuilder/blob/master/ChronoClashDeckBuilder/App_Data/Wireframe/CC%20Wireframe%20Deck%20Builder%20Page.png)

<a name="uml-diagrams"/>

### UML Diagrams

![UML CC Diagram](https://github.com/Zami77/ChronoClashDeckBuilder/blob/master/ChronoClashDeckBuilder/App_Data/CC%20Use%20Case%20UML.png)

<a name="requirements"/>

### Requirements
User Stories </br>
1.1. As a Card Game Player I want to view all cards released, so that I know all the cards. </br>
1.2	 As a Card Game Player I want to build decks so that I can have my decks saved to view later and share to others.</br>

Use-Cases</br>
2.1 Given user when they click on card list Then all cards are displayed </br>
2.2 Given user when they apply filters then all cards are filtered</br>
2.3 Given user when they save deck then the deck is saved to their user account</br>

Requirements</br>
4.1.1 User shall log in</br>
4.1.2 User shall create an account</br>
4.1.3. User shall view cards</br>
4.1.4 User shall build decks</br>
4.1.5 User shall save decks</br>
4.2.1 System shall provide webpage and UI</br>
4.3.1 Software shall compile list of Cards</br>
4.3.2 Software shall ensure decks that are being built are following the rules</br>
4.3.3 Software shall make sure decks are being saved to database</br>
4.3.4 Software shall make sure card database is up to date</br>

<a name="requirements-and-test-tables"/>

### Requirements and Test Table

| Requirements ID | Requirement Description                                                  | Test Method |
|-----------------|--------------------------------------------------------------------------|-------------|
| 4.1.1           | User Shall Log In                                                        | Test        |
| 4.1.2           | User shall create an account                                             | Test        |
| 4.1.3           | User shall view cards                                                    | Test        |
| 4.1.4           | User shall build decks                                                   | Test        |
| 4.1.5           | User shall save decks                                                    | Test        |
| 4.2.1           | System shall provide webpage and UI                                      | View        |
| 4.3.1           | Software shall compile list of cards                                     | View        |
| 4.3.2           | Software shall ensure decks that are being built are following the rules | Test        |
| 4.3.3           | Software shall make sure decks are being saved to the database           | Test        |
| 4.3.4           | Software shall make sure card database is up to date                     | View        |

| Test ID | Requirements ID | Test Procedure                                   | Current Status | TimeStamp |
|---------|-----------------|--------------------------------------------------|----------------|-----------|
| 1       | 4.1.1           | Attempt to login with valid and invalid accounts | Not Tested     |           |
| 2       | 4.1.2           | Attempt to create an accouont then login         | Not Tested     |           |
| 3       | 4.1.3           | Make sure cards are visible                      | Not Tested     |           |
| 4       | 4.1.4           | Attempt to make deck                             | Not Tested     |           |
| 5       | 4.1.5           | Attempt to save deck                             | Not Tested     |           |
| 6       | 4.2.1           | View all web pages                               | Not Tested     |           |
| 7       | 4.3.1           | View list of cards                               | Not Tested     |           |
| 8       | 4.3.2           | View if deck is created with invalid parameters  | Not Tested     |           |
| 9       | 4.3.3           | Save deck and see if it's saved to the account   | Not Tested     |           |
| 10      | 4.3.4           | View cards and make sure they are up to date     | Not Tested     |           |

### Card Data

An excel file for the [Card Data](https://1drv.ms/x/s!As_NDUCOYXoGgd5wPTa4tM9WGTctVg?e=bKFpsZ) These sheets automatically produces a SQL Query to be inserted into the database.

### Prototype

Link to the [Prototype](https://github.com/Zami77/ChronoClashDeckBuilder/tree/master/Prototype) ReadMe

