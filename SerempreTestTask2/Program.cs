// See https://aka.ms/new-console-template for more information


int numTeams = 6;
int[][][] table = GetTable(numTeams);

// Imprimir la tabla de partidos
for (int round = 0; round < table.Length; round++)
{
    Console.WriteLine($"Ronda {round + 1}:");
    for (int match = 0; match < table[round].Length; match++)
    {
        int[] teams = table[round][match];
        Console.WriteLine($"Partido {match + 1}: [{teams[0]}, {teams[1]}]");
    }
    Console.WriteLine();
}

static int[][][] GetTable(int numTeams)
{
    int numRounds = numTeams - 1;
    int numMatchesPerRound = numTeams / 2;

    int[][][] table = new int[numRounds][][];

    // Crear los equipos
    int[] teams = new int[numTeams];
    for (int i = 0; i < numTeams; i++)
    {
        teams[i] = i + 1;
    }

    // Generar la tabla de partidos por cada ronda
    for (int round = 0; round < numRounds; round++)
    {
        table[round] = new int[numMatchesPerRound][];

        for (int match = 0; match < numMatchesPerRound; match++)
        {
            int team1 = teams[match];
            int team2 = teams[numMatchesPerRound + match];

            table[round][match] = new int[] { team1, team2 };
        }

        // Rotar los equipos para la siguiente ronda
        RotateTeams(teams);
    }

    return table;
}

static void RotateTeams(int[] teams)
{
    int lastTeam = teams[teams.Length - 1];

    for (int i = teams.Length - 1; i > 1; i--)
    {
        teams[i] = teams[i - 1];
    }

    teams[1] = lastTeam;
}