using UnityEngine;
using UnityEngine.UI;

public class Escudeiro : MonoBehaviour
{
    Vector3 target;
    public GameObject jons;
    GameObject antigo;
    int layer;
    public static bool ativo;
    bool posicionado;

    private void Start()
    {

        layer = LayerMask.GetMask("Tile");
    }
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        //poder usar o botao se for o turno do player e se nao tiver posicionado

        if (Turns.playerTurn && !posicionado)
            GetComponent<Button>().interactable = true;

        else
            GetComponent<Button>().interactable = false;

        if (ativo)
        {
            //Posicionamento
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer) && hit.collider.CompareTag("Tile") && hit.collider.gameObject.GetComponent<Tile>().agentes == Agentes.Vazio)
            {
                //feedback
                if (antigo != hit.collider.gameObject)
                {
                    if (antigo != null)
                    {
                        antigo.GetComponent<Renderer>().material.color = Color.white;
                    }
                    antigo = hit.collider.gameObject;
                    hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
                //posicionar
                if (Input.GetMouseButtonDown(0))
                {
                    Turns.playerTurn = false;

                    target = new Vector3(hit.transform.position.x, hit.transform.position.y + .5f, hit.transform.position.z);
                    Instantiate(jons, target, Quaternion.identity);

                    
                    //terminar feedback
                    antigo.GetComponent<Renderer>().material.color = Color.white;
                    antigo = null;

                    //pos
                    posicionado = true;
                    ativo = !ativo;
                }
            }
            //resetar feedback
            else
            {
                if (antigo != null)
                {
                    antigo.GetComponent<Renderer>().material.color = Color.white;
                    antigo = null;
                }
            }
        }
    }

    public void Posicion()
    {
        ativo = !ativo;
    }
}
