using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class Sort : MonoBehaviour
{
    private Vector3 _lastPos;
    private bool kek;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 playerPos = GameManager.Instance.player.transform.position;
            playerPos.x += 3;
            for (int i = 0; i < GameManager.Instance.allies.Count; i++)
            {
                if (i == 0)
                {
                    GameManager.Instance.allies[i].agent.SetDestination(playerPos);
                }
                else
                {
                    GameManager.Instance.allies[i].agent
                        .SetDestination(new Vector3(_lastPos.x + 3, _lastPos.y, _lastPos.z));
                }

                GameManager.Instance.allies[i].transform.eulerAngles =
                    GameManager.Instance.player.transform.eulerAngles;
                _lastPos = GameManager.Instance.allies[i].agent.destination;
            }
            print("FINISH");
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            foreach (var item in GameManager.Instance.allies)
            {
                Debug.Log(item.rank);
            }
            GameManager.Instance.allies =  RealSort(GameManager.Instance.allies.ToArray()).ToList();
            Debug.Log("Sorted!");
            foreach (var item in GameManager.Instance.allies)
            {
                Debug.Log(item.rank);
            }

        }
            //StartCoroutine(SimpleSort());
    }



    IEnumerator SimpleSort()
    {
        Ally temp;
        for (int i = 0; i < GameManager.Instance.allies.Count-1; i++)
        {
            
            for (int j = i + 1; j < GameManager.Instance.allies.Count; j++)
            {
                GameManager.Instance.allies[i].rankTxt.color = Color.red;
                GameManager.Instance.allies[j].rankTxt.color = Color.green;
                if (GameManager.Instance.allies[i].rank < GameManager.Instance.allies[j].rank)
                {
                    GameManager.Instance.allies[i].rankTxt.color = Color.black;
                   temp = GameManager.Instance.allies[i];
                    GameManager.Instance.allies[i].agent
                        .SetDestination(GameManager.Instance.allies[j].transform.position);
                    print("switch");
                    GameManager.Instance.allies[i].rankTxt.color = Color.black;
                    GameManager.Instance.allies[j].rankTxt.color = Color.red;
                    GameManager.Instance.allies[j].agent
                        .SetDestination(temp.transform.position);
                    print("switch2");
                    yield return new WaitUntil((() => GameManager.Instance.allies[j].agent.hasPath && GameManager.Instance.allies[i].agent.hasPath));
                    GameManager.Instance.allies[i] = GameManager.Instance.allies[j];
                    GameManager.Instance.allies[j] = temp;
                    print("here");
                    yield return new WaitForSeconds(2f);
                    print("oop");
                }
                print("here");
                yield return new WaitForSeconds(1f);
                print("oop");
                GameManager.Instance.allies[j].rankTxt.color = Color.black;
            }
            GameManager.Instance.allies[i].rankTxt.color = Color.black;
            Z();
            yield return  new WaitForSeconds(1);

        }
    }

    private void Z()
    {
        Vector3 playerPos = GameManager.Instance.player.transform.position;
        playerPos.x += 3;
        for (int i = 0; i < GameManager.Instance.allies.Count; i++)
        {
            if (i == 0)
            {
                GameManager.Instance.allies[i].agent.SetDestination(playerPos);
            }
            else
            {
                GameManager.Instance.allies[i].agent
                    .SetDestination(new Vector3(_lastPos.x + 3, _lastPos.y, _lastPos.z));
            }

            GameManager.Instance.allies[i].transform.eulerAngles =
                GameManager.Instance.player.transform.eulerAngles;
            _lastPos = GameManager.Instance.allies[i].agent.destination;
        }
        print("FINISH");
    }

        public  Ally[] RealSort(Ally[] array)
        {
            Ally[] aux;
            while (!(MSort(array, out aux) == 1))
            {
                array = aux;
                aux = null;
            }
            return aux;
        }

        private  int MSort(Ally[]  arr, out Ally[]  aux)
        {
            int l_arr = 0;
            int r_arr = arr.Length - 1;
            aux = new Ally[arr.Length];
            int l_aux = 0;
            int r_aux = aux.Length - 1;
            bool left = true;
            int count = 0;

            while (l_arr <= r_arr)
            {
                Merge(arr, aux, ref l_arr, ref r_arr, ref l_aux, ref r_aux, left);
                count++;
                left = !left;
            }
            return count;
        }

        private  void Merge(Ally[] arr, Ally[] aux, ref int l_arr, ref int r_arr, ref int l_aux, ref int r_aux, bool left)
        {
            bool end_of_left = l_arr > r_arr;
            bool end_of_right = l_arr >= r_arr;
            while (!end_of_left && !end_of_right)
            {
                if (arr[l_arr].rank <= arr[r_arr].rank)
                {
                    end_of_left = PutElem(arr, aux, ref r_arr, ref l_arr, true, ref l_aux, ref r_aux, left);
                }
                else
                {
                    end_of_right = PutElem(arr, aux, ref r_arr, ref l_arr, false, ref l_aux, ref r_aux, left);
                }
            }
            while (!end_of_left)
            {
                end_of_left = PutElem(arr, aux, ref r_arr, ref l_arr, true, ref l_aux, ref r_aux, left);
            }
            while (!end_of_right)
            {
                end_of_right = PutElem(arr, aux, ref r_arr, ref l_arr, false, ref l_aux, ref r_aux, left);
            }
        }

        private bool  PutElem(Ally[]  arr, Ally[]  aux, ref int r_arr, ref int l_arr, bool left_arr, ref int l_aux, ref int r_aux, bool left_aux)
        {
            bool end = (left_arr ? l_arr + 1 >= r_arr : l_arr >= r_arr - 1) || 
            arr[left_arr ? l_arr : r_arr].rank > arr[left_arr ? l_arr + 1 : r_arr - 1].rank;
            int i = left_arr ? l_arr : r_arr;
            int where = left_aux ? l_aux + 1 : r_aux -1;
            var pos = arr[i].transform.position;
            arr[i].agent.SetDestination(new Vector3(pos.x - (i - where) * 3, pos.y, pos.z + 5));
            while(arr[i].transform.position != arr[i].agent.destination)
            {
                print(Time.deltaTime);
            }
            aux[left_aux ? l_aux++ : r_aux--] = arr[left_arr ? l_arr++ : r_arr--];
            return end;
        }
}





