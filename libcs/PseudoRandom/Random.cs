namespace libcs.PseudoRandom {

    public class LinearCongruentialGenerator {

        public int Modulus { get; private set; }
        public int Seed { get; private set; }
        public int Multiplier;
        public int CurrentStep = 0;


        public LinearCongruentialGenerator(int Seed, int Multiplier, int Modulus)
        {
            this.Modulus = Modulus;
            this.Seed = Seed;
            this.Multiplier = Multiplier;

            if(0 > Modulus)
            {

            }

            if(0 > Multiplier || Multiplier > Modulus)
            {

            }

            if(0 > Seed || Seed > Modulus)
            {

            }
        }

        public bool NextBool() {
            return (int.MaxValue/2 > Step());
        }

        public int NextNumber() => Step();

        public byte[] NextBytes(int Length) {
            byte[] Output = new byte[Length];
            for (int i = 0; i < Length; i++)
            {
                Output[i] = (byte)Step();
            }
            return Output;
        }

        int Step()
        {

            int b = CurrentStep;
            if(0 > b || b > Modulus)
            {
                CurrentStep = 0;
                return Step();
            }
            CurrentStep++;

            return  (Multiplier * Seed + b) % Modulus;

        }

    }

}
