# Sphero-Azure-GPS
How awesome would it be if you could control your Sphero remotely using Azure. You could be on vacation and you could control your Sphero back at home. What if then your Sphero could drive around your house like it had its own GPS, (Alright, I know its really not GPS). What if you could tell your Sphero to go into your living room or to roll downstairs into your basement. We could even expand this to use Machine learning to help Sphero to make better decisions. 

This is still a WIP and will continue to grow over time but if you have any questions feel free to email me at matthew.pasco@studentpartner.com

Thanks,

-Matt

___________________________________________________________________

WEEK 1
To get started

I have been working to make a more stable connection to interface between Azure. Currently I am making a Windows Universal app to interface with azure, I have a 'server' running node that talks to azure then relays commands to the Sphero.

How to update position:

Y             V

^

|             /

|           /

|         /

|       /

|    /

|  /    A

_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _  X

Assuming A is our angle, we can find out out Sphero's X and Y coordinates. Assuming we know the magnitude of V (magnitude being the distance traveled)

X = |V| cos(A)

Y = |V| sin(A)

We will be able to find A by using the Gyro sensor inside the Sphero, and the distance traveled by using a ratio of Time.

___________________________________________________________________


WEEK 2
Where did I leave off last week? Last week, I finished up the logic for moving using simple trig functions.

What have I implemented/changed/updated/improved/etc. this week? This week, I better tuned my distance that the sphero drives to what I think it drives, (made it more accurate). I now have been working on setting up stacks on Azure for my data.

What I’m looking to accomplish next: I am having a few issues with azure that is preventing me from moving forward I am looking to fixing that to keep going.

___________________________________________________________________


WEEK 3
Where did I leave off last week? Last week, I worked on setting up the Azure storage queue for sending commands to the Sphero.

What have I implemented/changed/updated/improved/etc. this week? This week, I worked on making data transfer faster as well as trying to fix some issues reading from the Sphero sensors.

What I’m looking to accomplish next: I would like to start logging all of the data back into Azure and make a map of where the sphero went, now since the sensors are able to be read.

___________________________________________________________________


WEEK 4
Where did I leave off last week? Last week, I worked on making data transfer faster as well as trying to fix some issues reading from the Sphero sensors.

What have I implemented/changed/updated/improved/etc. this week? This week, I made the app to allow Cortana integration, so you can control the sphero with your voice.

What I’m looking to accomplish next: I would like to make the voice recognition more clear, currently I have issues with Cortana thinking that the word “to” gets turned to “two” after I say “one”

Control Sphero through Cortana using your voice!
___________________________________________________________________


WEEK 5
Where did I leave off last week? Last week, I made the app to allow Cortana integration, so you can control the sphero with your voice.

What have I implemented/changed/updated/improved/etc. this week? This week, I made a custom control for windows phone that renders a graph of where the sphero has been. All data from and commands to the sphero are stream through Azure Storage Queues.

What I’m looking to accomplish next: Finalize project, work out any bugs, make the UI a little nicer and continue to fine tune the PID control on the sphero.

