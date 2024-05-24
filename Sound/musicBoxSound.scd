s.boot
NetAddr.localAddr;

(
SynthDef(\tone, { arg freq=0, amp=0.3, freqCut=800;

    var filteredSig;

    var env = EnvGen.kr(Env.perc(0.01, 1), doneAction: 2);

    var output = RLPF.ar(Saw.ar(freq), freqCut, rq:0.5) * env;



	Out.ar(0, {output * amp}!2);
}).add;

SynthDef(\chord, {
    | amp = 0.1, sustain = 1, f1=0, f2=0, f3=0, freqCut = 800|
    var env = EnvGen.kr(Env.perc(0.01, sustain), doneAction: 2);
	var sig = SinOsc.ar(f1) + SinOsc.ar(f2) + SinOsc.ar(f3) ;
	var output = ( RLPF.ar(sig, freqCut, rq: 0.5) ) * env;
	Out.ar(0, {output * amp}!2);
}).add;

)

Synth.new(\tone, [\freq, ~currentTone.midicps]);

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
];

~currentTone = 60;
)

(
OSCdef.new(
    \collision,
    { arg msg;
        var splitString = msg[1].asString.split($ );
		var bChord, sustain, chordAmp, octavMap, octavMult, toneMap, toneAdd;

		sustain = 3;
		chordAmp = 0.1;

		switch (splitString[0].asString,
			"chord", {
				// Oktav
				octavMap = linlin(splitString[2].asFloat, 0, 360, 0, 4).round;
				octavMap.postln;

				switch (splitString[1].asString,
					"C", {
						bChord = ~basicChords[0];
					},
					"G", {
						bChord = ~basicChords[1];
					},
					"D", {
						bChord = ~basicChords[2];
					},
					"A", {
						bChord = ~basicChords[3];
					},
					"E", {
						bChord = ~basicChords[4];
					},
					"B", {
						bChord = ~basicChords[5];
					},
					"Fiss", {
						bChord = ~basicChords[6];
					},
					"Ciss", {
						bChord = ~basicChords[7];
					},
					"F", {
						bChord = ~basicChords[8];
					},
					"Bess", {
						bChord = ~basicChords[9];
					},
					{
						// Default case
						"Default";
					}
				);

				~playChord.((bChord + (12 * octavMap)), chordAmp, sustain);
				splitString[1].asString.postln;
			},
			"tone", {
				// Update currentTone
				toneMap = linlin(splitString[1].asFloat, 0, 360, -4, 4).round;
				toneMap.postln;

					Synth.new(\tone, [\freq, (~currentTone + toneMap).midicps]);
			},
			{
				//Nothing
			}
		);
    },
    '/collision',
    nil, 12345
);

)


(
~playChord = { |notes, amp = 0.1, sustain = 1|
	Synth(\chord, [\f1, notes[0].midicps, \f2, notes[1].midicps, \f3, notes[2].midicps, \amp, amp, \sustain, sustain]);

};
)
(
var test = ~basicChords[0];
var test2 = ~basicChords[0] + 12;
test.postln;
test2.postln;


)
ServerMeter.new(s, 0, 2);
~playChord.(~basicChords[0], 0.1, 2);
~playChord.(~basicChords[1], 0.1, 2);
~playChord.(~basicChords[2], 0.1, 2);
~playChord.(~basicChords[3], 0.1, 2);
~playChord.([67, 71, 74], 0.1, 2);