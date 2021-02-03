using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtils {

    public interface IRandomUtil {

        /// <summary>
        /// return a random number  (min <= x <= max)
        /// </summary>
        int RandomNumber(int min, int max);

        /// <summary>
        /// return a random number (0 <= x)
        /// </summary>
        int RandomNumber();

        /// <summary>
        /// return a random number (0 <= x <= max)
        /// </summary>
        int RandomNumber(int max);

        /// <summary>
        /// return random string
        /// </summary>
        string RandomString(int size, bool lowerCase);

        /// <summary>
        /// return a random number between min and max and exclude array value
        /// </summary>
        int getRandomWithExclusion(int min, int max, int[] exclude);

        /// <summary>
        /// return a random number from min and exclude array value
        /// </summary>
        int getIntWithExclusion(int min, int[] exclude);
    }

    public class RandomUtil : IRandomUtil {

        public int RandomNumber(int min, int max) {
            Random rand = new Random();
            return rand.Next(min, max);
        }

        /// <summary>
        /// return a random number  (min <= x <= max)
        /// </summary>
        public int RandomNumber() {
            Random rand = new Random();
            return rand.Next();
        }

        public int RandomNumber(int max) {
            Random rand = new Random();
            return rand.Next(max);
        }

        public string RandomString(int size, bool lowerCase) {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            char ch;
            for(int i = 0; i < size; i++) {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                sb.Append(ch);
            }

            if(lowerCase) {
                return sb.ToString().ToLower();
            }

            return sb.ToString();
        }

        public int getRandomWithExclusion(int min, int max, int[] exclude) {
            Random rnd = new Random();
            int random = min + rnd.Next(max - min + 1 - exclude.Length);
            foreach(int ex in exclude) {
                if(random < ex) {
                    break;
                }
                random++;
            }
            return random;
        }

        public int getIntWithExclusion(int min, int[] exclude) {
            while(exclude.Contains(min)) {
                min++;
            }

            return min;
        }
    }
}