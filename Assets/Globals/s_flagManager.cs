using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_flagManager : s_singleton<s_flagManager>
{
    public List<ev_integer> GlobalFlagCache = new List<ev_integer>();
    public static Dictionary<string, int> GlobalFlags = new Dictionary<string, int>();
    public void SetNewFlags()
    {
        foreach (ev_integer e in GlobalFlagCache)
        {
            if (!GlobalFlags.ContainsKey(e.integer_name))
                GlobalFlags.Add(e.integer_name, e.integer);
        }
    }
    public void SetSavedFlags(dat_globalflags flgs)
    {
        foreach (KeyValuePair<string, int> e in flgs.Flags)
        {
            if (!GlobalFlags.ContainsKey(e.Key))
                GlobalFlags.Add(e.Key, e.Value);
            else
                GlobalFlags[e.Key] = e.Value;
        }
    }
    public static void SetGlobalFlag(string flagname, int flag)
    {
        if (!GlobalFlags.ContainsKey(flagname))
        {
            GlobalFlags.Add(flagname, flag);
            return;
        }
        GlobalFlags[flagname] = flag;
    }

    public static int GetGlobalFlag(string flagname)
    {
        if (!GlobalFlags.ContainsKey(flagname))
        {
            return int.MinValue;
        }
        return GlobalFlags[flagname];
    }


    public void LoadFlag(dat_globalflags flag)
    {
        GlobalFlags = flag.Flags;
    }
}
