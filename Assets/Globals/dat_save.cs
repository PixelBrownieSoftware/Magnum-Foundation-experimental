using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct ev_integer
{
    public int integer;
    public string integer_name;
}

[Serializable]
public class triggerState
{
    public string name;
    public string scene;
    public bool switchA;
    public bool switchB;
    public bool switchC;
    public bool switchD;
    public triggerState(string name, string scene, bool switchA)
    {
        this.name = name;
        this.scene = scene;
        this.switchA = switchA;
    }
}
[Serializable]
public struct dat_globalflags
{
    public dat_globalflags(Dictionary<string, int> Flags)
    {
        this.Flags = Flags;
    }
    public Dictionary<string, int> Flags;
}

[Serializable]
public struct s_save_vector
{
    public float x, y, z;
    public s_save_vector(float x, float y)
    {
        this.x = x;
        this.y = y;
        z = 0;
    }
    public s_save_vector(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public s_save_vector(Vector2 pos)
    {
        x = pos.x;
        y = pos.y;
        z = 0;
    }
    public s_save_vector(Vector3 pos)
    {
        x = pos.x;
        y = pos.y;
        z = pos.z;
    }

    public static s_save_vector operator +(s_save_vector vec, Vector3 vec2)
    {
        vec.x = vec2.x;
        vec.y = vec2.y;
        vec.z = vec2.z;
        return vec;
    }
}

[Serializable]
public class dat_save
{
    public enum TYPEOFVAL { INT, STRING, FLOAT, SHORT, UINT };


    public void AddStrings() { }

    public dat_save()
    {
    }
    public dat_save(dat_globalflags gbflg, int health, int MAXhp, string currentmap, Vector2 location, List<triggerState> trigStates)
    {
        hp = health;
        this.trigStates = trigStates;
        this.gbflg = gbflg;
        this.MAXhp = MAXhp;
        this.currentmap = currentmap;
        this.location = new s_save_vector(location.x, location.y);
    }
    public List<triggerState> trigStates;
    public int hp;
    public int MAXhp;
    public string currentmap;
    public dat_globalflags gbflg;
    public s_save_vector location;
}
