This is custom version of the Open Source application HacmeBank created by Dinis Cruz (who was one of the original developers of HacmeBank) originally published by Foundstone here: http://www.foundstone.com/us/resources/proddesc/hacmebank.htm & http://www.foundstone.com/us/resources/freetools/hacmebank2_source.zip

The original version of HacmeBank was released under the Apache Open Source license, so to make matters simpler, this version is also released under the same license. See the file apache.rtf for more details.

This version also contains extra code which was never published on the original version of HacmeBank (for example the SQLInjection_DatabaseExplorer)

Change log:
- Upgraded to Visual Studio 2008 (keept on Version 2.0 of the .NET Framework)
- Added SqlInjection_DatabaseExplorer project
- Added FS_HttpModule project
- Added ValidatorNET_GAC_Assembly project
- Created a new Database called HacmeBank_Database.mdf (the idea is to remove dependency with SQL Server
- Populated database with the SQL Queries from: HacmeBank_v2_WS\install\FoundStoneBank_export.sql
- Changed web.config so that we are going to the local database
- Fixed a couple bugs
- Added SqlInjection_DatabaseExplorer (and clean it up quite a bit (Although there is still a lot to do, and I need to move it into O2)

Dinis Cruz 7th December 2008