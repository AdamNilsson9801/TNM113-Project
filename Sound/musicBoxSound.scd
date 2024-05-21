s.boot
NetAddr.localAddr;

(
OSCdef.new(
	\collision,
	{arg msg;
		msg[1].postln;

	},
	'/collision',
	nil,12345
);
)


/*
(
OSCdef(\collision, { arg inputmsg;
	inputmsg[1].postln;
	if (inputmsg.size > 1) {
		var msg = inputmsg[1].asString;
		msg.postln;
	};
}, '/collision');
)*/
