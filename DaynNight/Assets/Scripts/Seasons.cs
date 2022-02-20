using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seasons : MonoBehaviour
{
    public int day = 0;
    private string whichSeason = "spring";
    internal static float deltaTime;

    [SerializeField]
    GameObject TreeSpring1;

    [SerializeField]
    GameObject TreeSpring5;

    [SerializeField]
    GameObject TreeSpring2;

    [SerializeField]
    GameObject TreeSummer1;

    [SerializeField]
    GameObject TreeSummer5;

    [SerializeField]
    GameObject TreeSummer2;

    [SerializeField]
    GameObject TreeAutumn1;

    [SerializeField]
    GameObject TreeAutumn5;

    [SerializeField]
    GameObject TreeAutumn2;

    [SerializeField]
    GameObject TreeWinter1;

    [SerializeField]
    GameObject TreeWinter5;

    [SerializeField]
    GameObject TreeWinter2;

    [SerializeField]
    GameObject TreeParent;

    [SerializeField]
    GameObject BushParent;

    [SerializeField]
    GameObject Rock1;

    [SerializeField]
    GameObject Rock2;

    [SerializeField]
    GameObject winterRock1;

    [SerializeField]
    GameObject winterRock2;

    [SerializeField]
    GameObject Branch;

    [SerializeField]
    GameObject winterBranch;

    [SerializeField]
    GameObject Bush1;

    [SerializeField]
    GameObject Bush4;

    [SerializeField]
    GameObject autumnBush1;

    [SerializeField]
    GameObject autumnBush4;

    [SerializeField]
    GameObject springFlower;

    [SerializeField]
    GameObject Flower;

    private GameObject tree1;
    private GameObject tree2;
    private GameObject tree4;

    private GameObject bush1;
    private GameObject bush2;
    private GameObject bush3;
    private GameObject bush4;

    private GameObject branch;
    private GameObject rok1;
    private GameObject rok2;
    private GameObject flower;


    private bool canWe = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        springToSummer();
        summerToAutumn();
        autumnToWinter();
        winterToSpring();
        Debug.Log(whichSeason);
    }

    private void springToSummer()
    {
        if (day > 0 && whichSeason == "spring" && canWe == true)
        {
            tree1 = GameObject.Find("TreeSpring1");
            var treeTemp1 = Instantiate(TreeSummer1, tree1.transform.position, tree1.transform.rotation, TreeParent.transform);
            treeTemp1.name = "TreeSummer1";
            Destroy(tree1);

            tree2 = GameObject.Find("TreeSpring2");
            var treeTemp2 = Instantiate(TreeSummer2, tree2.transform.position, tree2.transform.rotation, TreeParent.transform);
            treeTemp2.name = "TreeSummer2";
            Destroy(tree2);

            tree4 = GameObject.Find("TreeSpring5");
            var treeTemp3 = Instantiate(TreeSummer5, tree4.transform.position, tree4.transform.rotation, TreeParent.transform);
            treeTemp3.name = "TreeSummer5";
            Destroy(tree4);

            whichSeason = "summer";

        }
    }

    private void summerToAutumn()
    {
        if (day > 4 && whichSeason == "summer")
        {
            tree1 = GameObject.Find("TreeSummer1");
            var treeTemp1 = Instantiate(TreeAutumn1, tree1.transform.position, tree1.transform.rotation, TreeParent.transform);
            treeTemp1.name = "TreeAutumn1";
            Destroy(tree1);

            tree2 = GameObject.Find("TreeSummer2");
            var treeTemp2 = Instantiate(TreeAutumn2, tree2.transform.position, tree2.transform.rotation, TreeParent.transform);
            treeTemp2.name = "TreeAutumn2";
            Destroy(tree2);

            tree4 = GameObject.Find("TreeSummer5");
            var treeTemp3 = Instantiate(TreeAutumn5, tree4.transform.position, tree4.transform.rotation, TreeParent.transform);
            treeTemp3.name = "TreeAutumn5";
            Destroy(tree4);

            bush1 = GameObject.Find("Bush1");
            var bushTemp1= Instantiate(autumnBush1, bush1.transform.position, bush1.transform.rotation, BushParent.transform);
            bushTemp1.name = "Bush1";
            Destroy(bush1);

            bush2 = GameObject.Find("Bush2");
            var bushTemp2 = Instantiate(autumnBush1, bush2.transform.position, bush2.transform.rotation, BushParent.transform);
            bushTemp2.name = "Bush2";
            Destroy(bush2);

            bush3 = GameObject.Find("Bush3");
            var bushTemp3 = Instantiate(autumnBush1, bush3.transform.position, bush3.transform.rotation,  BushParent.transform);
            bushTemp3.name = "Bush3";
            Destroy(bush3);

            bush4 = GameObject.Find("Bush4");
            var bushTemp4 = Instantiate(autumnBush4, bush4.transform.position, bush4.transform.rotation, BushParent.transform);
            bushTemp4.name = "Bush4";
            Destroy(bush4);

            whichSeason = "autumn";
        }
    }

    private void autumnToWinter()
    {
        if (day > 8 && whichSeason == "autumn")
        {
            tree1 = GameObject.Find("TreeAutumn1");
            var treeTemp1 = Instantiate(TreeWinter1, tree1.transform.position, tree1.transform.rotation, TreeParent.transform);
            treeTemp1.name = "TreeWinter1";
            Destroy(tree1);

            tree2 = GameObject.Find("TreeAutumn2");
            var treeTemp2 = Instantiate(TreeWinter2, tree2.transform.position, tree2.transform.rotation, TreeParent.transform);
            treeTemp2.name = "TreeWinter2";
            Destroy(tree2);

            tree4 = GameObject.Find("TreeAutumn5");
            var treeTemp3 = Instantiate(TreeWinter5, tree4.transform.position, tree4.transform.rotation, TreeParent.transform);
            treeTemp3.name = "TreeWinter5";
            Destroy(tree4);

            branch = GameObject.Find("Branch");
            var branchTemp = Instantiate(winterBranch, branch.transform.position, branch.transform.rotation);
            branchTemp.name = "Branch";
            Destroy(branch);

            rok1 = GameObject.Find("Rock1");
            var rock1Temp = Instantiate(winterRock1, rok1.transform.position, rok1.transform.rotation);
            rock1Temp.name = "Branch";
            Destroy(rok1);

            rok2 = GameObject.Find("Rock2");
            var rock2Temp = Instantiate(winterRock2, rok2.transform.position, rok2.transform.rotation);
            rock2Temp.name = "Rock2";
            Destroy(rok2);

            bush1 = GameObject.Find("Bush1");
            bush1.transform.position = new Vector3(0, -50, 0);

            canWe = false;
            whichSeason = "winter";
        }
    }

    private void winterToSpring()
    {
        if (day > 12 && whichSeason == "winter")
        {
            tree1 = GameObject.Find("TreeWinter1");
            var treeTemp1 = Instantiate(TreeSpring1, tree1.transform.position, tree1.transform.rotation, TreeParent.transform);
            treeTemp1.name = "TreeSpring1";
            Destroy(tree1);

            tree2 = GameObject.Find("TreeWinter2");
            var treeTemp2 = Instantiate(TreeSpring2, tree2.transform.position, tree2.transform.rotation, TreeParent.transform);
            treeTemp2.name = "TreeSpring2";
            Destroy(tree2);

            tree4 = GameObject.Find("TreeWinter5");
            var treeTemp3 = Instantiate(TreeSpring5, tree4.transform.position, tree4.transform.rotation, TreeParent.transform);
            treeTemp3.name = "TreeSpring5";
            Destroy(tree4);

            branch = GameObject.Find("Branch");
            var branchTemp = Instantiate(Branch, branch.transform.position, branch.transform.rotation);
            branchTemp.name = "Branch";
            Destroy(branch);

            rok1 = GameObject.Find("Rock1");
            var rock1Temp = Instantiate(Rock1, rok1.transform.position, rok1.transform.rotation);
            branchTemp.name = "Branch";
            Destroy(rok1);

            rok2 = GameObject.Find("Rock2");
            var rock2Temp = Instantiate(Rock2, rok2.transform.position, rok2.transform.rotation);
            branchTemp.name = "Rock2";
            Destroy(rok2);

            whichSeason = "spring";
            resetDay();
            canWe = true;
        }
    }

    private void resetDay()
    {
        day = 0;
    }
}
