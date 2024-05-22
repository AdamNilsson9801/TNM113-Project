s.boot
NetAddr.localAddr;

(
SynthDef(\bell, { arg level = 0;

    var envelope = EnvGen.kr(Env.perc(attackTime: 0.05, releaseTime: 0.2, level: 1.0, curve: -4.0));
    var output = SinOsc.ar(freq: 200) * envelope;

    Out.ar(0, { output * level } ! 2);
	DetectSilence.ar({ output * level }, doneAction: 2);
}).add;

SynthDef(\chord, {
    |freq = 440, amp = 0.1, sustain = 1|
    var env = EnvGen.kr(Env.perc(0.01, sustain), doneAction: 2);
    var output = SinOsc.ar(freq) * env * amp;
	Out.ar(0, {output}!2);
}).add;

)

(
~basicChords = [
	[60, 64, 67], //C-dur
	[67, 71, 74], //G-dur
	[62, 66, 69], //D-dur
	[69, 73, 76], //A-dur
	[64, 68, 71], //E-dur
	[71, 75, 78], //B-dur
	[66, 71, 73], //Fiss-dur
	[61, 65, 68], //Ciss-dur
	[65, 69, 72], //F-dur
	[70, 74, 77]  //Bess-dur
]
)

(
OSCdef.new(
    \collision,
    { arg msg;
        var splitString = msg[1].asString.split($ );
		var bChord, sustain, chordAmp, octavMap, octavMult;

		sustain = 3;
		chordAmp = 0.2;

		if(splitString[0].asString == "chord") {

			//Oktav
			octavMap = linlin(splitString[2].asFloat, 0, 360, 0, 4).round;
			octavMap.postln;
			switch (octavMap.asInteger,
				0, { octavMult = 0},
				1, { octavMult = 1 },
				2, { octavMult = 2 },
				3, { octavMult = -1 },
				4, { octavMult = -2 },

			);

			if (splitString[1].asString == "C") {
				bChord = ~basicChords[0];
				~playChord.((bChord + (12*octavMult)), chordAmp, sustain);
				"C".postln;
			} {
				if (splitString[1].asString == "G") {
					bChord = ~basicChords[1];
					~playChord.((bChord + (12*octavMult)), chordAmp, sustain);
					"G".postln;
				} {
					if (splitString[1].asString == "D") {
						bChord = ~basicChords[2];
						~playChord.((bChord + (12*octavMult)), chordAmp, sustain);
						"D".postln;
					} {
						if (splitString[1].asString == "A") {
							bChord = ~basicChords[3];
							~playChord.((bChord + (12*octavMult)), chordAmp, sustain);
							"A".postln;
						} {
							if (splitString[1].asString == "E") {
								bChord = ~basicChords[4];
								~playChord.((bChord + (12*octavMult)), chordAmp, sustain);
								"E".postln;
							} {
								if (splitString[1].asString == "B") {
									bChord = ~basicChords[5];
									~playChord.((bChord + (12*octavMult)), chordAmp, sustain);
									"B".postln;
								} {
									if (splitString[1].asString == "Fiss") {
										bChord = ~basicChords[6];
										~playChord.((bChord + (12*octavMult)), chordAmp, sustain);
										"Fiss".postln;
									} {
										if (splitString[1].asString == "Ciss") {
											bChord = ~basicChords[7];
											~playChord.((bChord + (12*octavMult)), chordAmp, sustain);
											"Ciss".postln;
										} {
											if (splitString[1].asString == "F") {
												bChord = ~basicChords[8];
												~playChord.((bChord + (12*octavMult)), chordAmp, sustain);
												"F".postln;
											} {
												//Bess
												bChord = ~basicChords[9];
												~playChord.((bChord + (12*octavMult)), chordAmp, sustain);
												"Bess".postln;

											};
										};
									};
								};
							};
						};
					};
				};
			};

            "---------".postln;
            ~playChord.([60, 64, 67], 0.1, 2);
        } {
            // ~playChord.([60, 64, 67], 0.1, 2);
            Synth.new(\bell, [\level, 0.5]);
            msg[1].postln;
			"---------".postln;
        };
    },
    '/collision',
    nil, 12345
);

)


(
~playChord = { |notes, amp = 0.1, sustain = 1|
    notes.do { |note|
        Synth(\chord, [\freq, note.midicps, \amp, amp, \sustain, sustain]);
    };
};
)
(
var test = ~basicChords[0];
var test2 = ~basicChords[0] + 12;
test.postln;
test2.postln;


)

~playChord.(~basicChords[0], 0.1, 2);
~playChord.([67, 71, 74], 0.1, 2);