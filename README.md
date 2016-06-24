LiveSplit.ComponentAutosplitter
=================

LiveSplit auto splitter for Star Trek: Voyager - Elite Force. Can also pause LiveSplits game timer while in loading screens.

Installation
------------
Enter "Star Trek: Voyager - Elite Force" in LiveSplit's splits editor and click activate.

Usage
-----
Move the events that you would like the autosplitter to split on into the left list. The events are sorted by the order in which they occure. If you don't know which mapname belongs to which level you can i.e. type "map borg1" into the console (default key to open the console is left to "1"). A basic setup that splits on every bigger section would use these events:

  * Loaded 'borg1'
  * Loaded 'voy1'
  * Loaded 'stasis1'
  * Loaded 'voy6'
  * Loaded 'scav1'
  * Loaded 'voy9'
  * Loaded 'borg3'
  * Loaded 'voy13'
  * Loaded 'dn1'
  * Loaded 'voy16'
  * Loaded 'forge1'
  * Loaded 'forgeboss'
  * Vorsoth dead

Keep in mind that you will have to setup your splits accordingly.
##### Pause game time
If you activate this option, the autosplitter will pause the game time when the game is loading, or in the main menu etc. This does not affect the realtime at all.
##### Notes
  * you probably want to use "Vorsoth dead" as your last event, as you don't have control over Munro from that point on
  * every map list states that there is a map 'train'. I'm not sure whether that's only my version, but that map doesn't exist for me. I included it nevertheless, in case that other versions contain this map name.
  * i encourage you to use the "Loaded 'mapname'" events rather than the "Finished 'mapname'" events, because the "finished" ones are less precise, as the autosplitter has to wait for the new mapname to appear in memory before splitting

Thanks
------
  * CryZe for the help to getting me started and reading the memory of the game process
  * [LiveSplit](http://livesplit.org/)
