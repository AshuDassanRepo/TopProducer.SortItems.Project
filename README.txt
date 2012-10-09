Top Producer - Sort Items Solution - Technical Evaluation

---------------------------------------------------------------
                       ASSUMPTIONS
---------------------------------------------------------------
1. Each item will have a unique name.
2. Unamed and named items without dependencies are treated the same.

---------------------------------------------------------------
                       EXPLANATION
---------------------------------------------------------------
I basically created three projects within the single solution file.
Each project is responsbile for a particular role. For example the
TopProducer.Enumerations project is solely responsible for all the
enumerations that will be used throughout the entire project. I 
hardcoded the items that I worked with and what dependency each item
has.

In order to run open the visual Studio solution file and run the project
from through that way.
