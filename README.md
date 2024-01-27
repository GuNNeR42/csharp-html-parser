# HTML CSV processing

This project allows you to import data from CSV file and generate a new HTML file with processed information using the provided HTML template. 
The exported HTML file will contain information about game purchases starting from a user-specified date.

## Running the program

### 1. ~~Use pre-built binaries~~

_TBD_

### 2. Build 
1. Clone the repository:
```
git clone https://github.com/GuNNeR42/csharp-html-parser
```
2. Build the app
```
dotnet publish -r win-x64
```

Please note you should always specify your runtime

## Usage

### 1. Default values

```
DataPath = "./game_orders.csv";
TemplatePath = "./template.html";
ExportPath = "./export.html";
LogPath = "./log.txt";
UserInputDateTimeFormat = "yyyy-MM-dd";
HtmlParseDateTimeFormat = "dd/MM/yyyy";
FirstLineHeader = true;
```

These are the default values
At this time, they can only be changed inside the code : `DefaultSettings.cs`
_TBD_ : Change to JSON and implement ability to change values from CLI 

### 2. CSV format

CSV files ready to parse should be in this format

```
UserEmail, GameTitle, Platform, OrderDate, OrderLocation

```
Because the `FirstLineHeader` value is `true`, you should always include header inside the CSV file
`OrderDate` should be in format specified in `DefaultSettings`

### 3. HTML export format

App returns `export.html` file that contains processed data as follows:

**Header:**
+ `Start date` and `End date` specified by user in the CLI

**Table Contents:**

+ **Game Title**: The name of the game.
+ **Purchase Count**: The number of times the game has been purchased since the specified date.
+ **Most Used Platform**: The most frequently used platform for the particular game.
+ **Last Purchase Date**: The date of the last purchase of the game.
