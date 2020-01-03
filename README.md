ChangeName
==========

A TShock plugin, allows changing a player's name and chatting from server rather than "broadcasting". Is not compatible with ChatAboveHeads (yet), just disables it.

Description:
Allows changing a player's name
Allows chatting from console rather than "broadcasting"
Permissions:
changenames - Allows /chname
oldnames - Allows /oldname
selfname - Allows /selfname
Commands:
/chname [player] [newname] - Changes [player]'s name to [newname]
/selfname [newname] - Changes your name to [newname]
/oldname [player] - Retrieves [player]'s old name
/chat [message] - Sends a usual chat message
Read "Usage" to have basic understanding of how all this works
Usage:
/chname finds player by part of his name or by IX.
/chname accepts extra argument. If it is present (doesn't really matter what it is) - broadcast "[player] has changed [oldName]'s to [newName]" will NOT appear. (Example: /chname Someone Someone1 true)
/selfname can be used in console, that would change its name (default is Server) to a name you want. Then, you can execute commands just as if you were on the server, it will show the name you set.
You can actually "chat" from console using /chat . It will show the message as if you were on the server, useful with /selfname.
/chat works as if EnableChatAboveHeads=false, even if it is not
Changelog:
v. 1.2.5 - API 1.17
v. 1.2.4 - API 1.16
v. 1.2.3 - API 1.15
v.1.2.2.7 - Another check to /selfname.
v.1.2.2.6 - Added some checks to /selfname. /chname still allows you to mess around in any way you want.
v.1.2.2 - ChatAboveHeads is now completely handled by TShock.
v.1.2.1 - Added tshock.canchat permission check for /all
v.1.2 - TShock 4.2 + HousingDistricts fix (the double-chat with House chat bug)
v.1.0.0.3 - Deprected extra argument for /selfname
v. 1.0.0.2 - Fixed Bug with ChatAboveHeads
v. 1.0.0.1 - Added ChatAboveHeads support

changenames - Allows /chname
oldnames - Allows /oldname
selfname - Allows /selfname

[ChangeName](https://tshock.co/xf/index.php?resources/changename.85/)
