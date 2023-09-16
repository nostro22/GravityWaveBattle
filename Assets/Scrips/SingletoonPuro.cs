using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SingletoonPuro 
{

    private static SingletoonPuro instance = null;

    private SingletoonPuro()//El constructor es privado
    {
        Instace();
        
    }

    public static SingletoonPuro Instace()
    {
        if (instance == null)
        {
            instance = new SingletoonPuro();
        }
          return instance; 
    }

}
