using System;

public class MesinKopi
{
    // ENUM STATE
    public enum CoffeeState
    {
        OFF,
        STANDBY,
        BREWING,
        MAINTENANCE
    }

    // ENUM TRIGGER
    public enum Trigger
    {
        POWER_ON,
        POWER_OFF,
        START_BREW,
        FINISH_BREW,
        START_MAINTENANCE,
        FINISH_MAINTENANCE
    }

    // State awal
    public CoffeeState currentState = CoffeeState.OFF;

    // Class Transition
    public class Transition
    {
        public CoffeeState StateAwal;
        public CoffeeState StateAkhir;
        public Trigger Trigger;

        public Transition(CoffeeState stateAwal, CoffeeState stateAkhir, Trigger trigger)
        {
            this.StateAwal = stateAwal;
            this.StateAkhir = stateAkhir;
            this.Trigger = trigger;
        }
    }

    // Daftar semua transisi valid
    Transition[] transitions =
    {
        new Transition(CoffeeState.OFF, CoffeeState.STANDBY, Trigger.POWER_ON),
        new Transition(CoffeeState.STANDBY, CoffeeState.OFF, Trigger.POWER_OFF),
        new Transition(CoffeeState.STANDBY, CoffeeState.BREWING, Trigger.START_BREW),
        new Transition(CoffeeState.BREWING, CoffeeState.STANDBY, Trigger.FINISH_BREW),
        new Transition(CoffeeState.STANDBY, CoffeeState.MAINTENANCE, Trigger.START_MAINTENANCE),
        new Transition(CoffeeState.MAINTENANCE, CoffeeState.STANDBY, Trigger.FINISH_MAINTENANCE)
    };

    // Method mencari next state
    public CoffeeState GetNextState(CoffeeState stateAwal, Trigger trigger)
    {
        CoffeeState stateAkhir = stateAwal;

        for (int i = 0; i < transitions.Length; i++)
        {
            if (stateAwal == transitions[i].StateAwal &&
                trigger == transitions[i].Trigger)
            {
                stateAkhir = transitions[i].StateAkhir;
            }
        }

        return stateAkhir;
    }

    // Method untuk mengaktifkan trigger
    public void ActivateTrigger(Trigger trigger)
    {
        CoffeeState prevState = currentState;
        CoffeeState nextState = GetNextState(currentState, trigger);

        if (prevState == nextState)
        {
            Console.WriteLine("Perubahan state tidak valid");
        }
        else
        {
            Console.WriteLine($"Mesin {prevState} berubah menjadi {nextState}");
            currentState = nextState;
        }
    }

    // MAIN
    public static void Main(string[] args)
    {
        MesinKopi mesin = new MesinKopi();

        Console.WriteLine($"State awal: {mesin.currentState}");

        mesin.ActivateTrigger(Trigger.POWER_ON);           // Off → Standby
        mesin.ActivateTrigger(Trigger.START_BREW);         // Standby → Brewing
        mesin.ActivateTrigger(Trigger.FINISH_BREW);        // Brewing → Standby
        mesin.ActivateTrigger(Trigger.START_MAINTENANCE);  // Standby → Maintenance
        mesin.ActivateTrigger(Trigger.FINISH_MAINTENANCE); // Maintenance → Standby
        mesin.ActivateTrigger(Trigger.POWER_OFF);          // Standby → Off
    }
}