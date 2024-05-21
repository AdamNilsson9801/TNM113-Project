(
// Server.scd
Server.all("n_channels", 16);
Server.all("buf_size", 1024);
s.boot;
)

(
OSCdef(\collision, { arg inputmsg;


	if (inputmsg.size > 1) {
		var msg = inputmsg[1].asString;
		msg.postln;
	};

}, 'collision');
)

(
    SynthDef("simple_synth", {
        arg freq = 440, amp = 0.5;
        var env = EnvGen.ar(Env.linen(0, 1, 0.1), doneAction: 2);
        var osc = SinOsc.ar(freq) * env * amp;
        Out.ar(0, osc);
    }).add;
)