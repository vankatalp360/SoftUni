<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Product;
use AppBundle\Form\ProductType;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class ProductController extends Controller
{
    /**
     * @param Request $request
     * @Route("/", name="index")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function index(Request $request)
    {
        $productRepository=$this->getDoctrine()->getRepository(Product::class);
        $products=$productRepository->findAll();

        return $this->render("product/index.html.twig",
            [
                'products'=>$products
            ]);
	}

    /**
     * @param Request $request
     * @Route("/create", name="create")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function create(Request $request)
    {
        $product = new Product();
        $form = $this->createForm(ProductType::class,$product);
        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()) {
            if ($product->getName() == null || $product->getPriority() == null ||
                $product->getStatus() == null || $product->getQuantity() == null
            ) {
                return $this->redirectToRoute("create");
            }
            $entityManager = $this->getDoctrine()->getManager();
            $entityManager->persist($product);
            $entityManager->flush();

            return $this->redirectToRoute("index");
        }
        return $this->render('product/create.html.twig',
            [
                'form' => $form->createView()
            ]);
	}

    /**
     * @Route("/edit/{id}", name="edit")
     *
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function edit($id, Request $request)
    {
        $productRepository = $this->getDoctrine()->getRepository(Product::class);

        $product = $productRepository->find($id);

        if ($productRepository==null){
            return $this->redirectToRoute("index");
        }

        $form = $this->createForm(ProductType::class,$product);
        $form->handleRequest($request);

        if ($form->isSubmitted()&&$form->isValid()){

            $em = $this->getDoctrine()->getManager();

            $em->merge($product);
            $em->flush();

            return $this->redirectToRoute("index");
        }
        return $this->render('product/edit.html.twig',
            [
                'product'=>$product,
                'form'=>$form->createView()
            ]);    }
}
